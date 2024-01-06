import { Component } from '@angular/core';
import { AppService } from '../services/app.service';
import { ApiService } from '../services/api.service';
import { UserGridService } from './user-grid.service';
import { UserModel } from '../Models/UserModel';
import { Constants } from '../share/constants';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-users-grid',
  templateUrl: './users-grid.component.html',
  styleUrls: ['./users-grid.component.scss']
})
export class UsersGridComponent {
  isNew:boolean=false;
  users:Array<UserModel>=[];
  columnsSchema:any=this.userServ.COLUMNS_SCHEMA;
  displayedColumns: string[] = this.userServ.COLUMNS_SCHEMA.map(col => col.key);
  genders:string[] = this.userServ.genders;
  private $getSub:Subscription;
  private $addSub:Subscription;
  private $updateSub:Subscription;
  private $deleteSub:Subscription;

  constructor(private app:AppService, 
    private api:ApiService, 
    private userServ:UserGridService){}

  ngOnInit(){
   this.getAllUsers();
  }

  getAllUsers(){
    this.app.showLoader=true;
    this.$getSub = this.api.getAll().subscribe((res:any)=>{
      if(res){
        this.users = res.map((u:any)=>({
          ...new UserModel, ...u
        }));
      }
      this.app.showLoader=false;
    })
  }

  getErrorMsg(user:UserModel,key:string){
    return this.userServ.getErrorMsg(user,key);
  }

  onCheckValid(ev:any){
    let isNumber = Constants.REGEX.ONLYNUMBER.test(ev.target.value);
    if(isNumber){
      return isNumber;
    }
    return ev.target.validity.valid
  }

  checkRequired(user:UserModel){
    let requiredKeys = ['name','identity','birthDate'];
    for(const key of requiredKeys){
      if(!(user as any)[key])
        return false;
    }
    return true;
  }
  addRow(){
    let newUsers = this.users.filter(u=>u.id == 0);
    if(newUsers.length == 0){
      let user = new UserModel();
      user.isNew = true;
      user.isEdit = true;
      this.users = [user, ...this.users];
    }
  }

  onDone(user:UserModel){

    if(this.checkRequired(user) && user.isValid){
      this.app.showLoader = true;
      if(user.isNew){
       this.$addSub = this.api.add(user).subscribe((res:any)=>{
          if(res){
            this.getAllUsers();
          }
          this.app.showLoader=false;
        })
      }
      else{
       this.$updateSub = this.api.update(user).subscribe((res:any)=>{
          if(res){
            this.getAllUsers();
          }
          this.app.showLoader=false;
        })
      }
      user.isEdit = !user.isEdit;
    }
    else{
      alert('Please fill all required data');
    }
  }
  removeUser(identity:string){
    this.app.showLoader = true;
    this.$deleteSub = this.api.delete(identity).subscribe((res:any)=>{
      if(res && res.isDeleted){
        this.getAllUsers();
      }
      this.app.showLoader = false;
    })
  }

  ngOnDestroy(){
    this.$getSub.unsubscribe();
    this.$addSub.unsubscribe();
    this.$updateSub.unsubscribe();
    this.$deleteSub.unsubscribe();
  }
}

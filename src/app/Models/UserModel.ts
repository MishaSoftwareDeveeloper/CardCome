export class UserModel  {
    id:number = 0;
    identity:string='';
    name:string='';
    mail?:string;
    birthDate?:Date;
    gender:string='other';
    phoneNumber?:string;
    isNew:boolean = false;
    isEdit:boolean = false;
    isValid:boolean = false;
}
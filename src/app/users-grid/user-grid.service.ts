import { Injectable } from '@angular/core';
import { Constants } from '../share/constants';

@Injectable({
  providedIn: 'root'
})
export class UserGridService {

  public COLUMNS_SCHEMA = [
    {
        key: "identity",
        type: "text",
        label: "Passport",
        required:true,
        pattern:Constants.REGEX.ONLYNUMBER
    },
    {
        key: "name",
        type: "text",
        label: "Name",
        required:true
    },
    {
        key: "mail",
        type: "email",
        label: "Email",
        pattern:Constants.REGEX.EMAIL
    },
    {
      key: "birthDate",
      type: "date",
      label: "Date of Birth",
      required:true
    },
    {
        key: "gender",
        type: "select",
        label: "Gender"
    },
    {
      key: "phoneNumber",
      type: "text",
      label: "Phone number",
      pattern:Constants.REGEX.ONLYNUMBER
    },
    {
      key: "isEdit",
      type: "isEdit",
      label: ""
    }
  ]

  public genders=['other','male','female'];

  constructor() { }

  get errorMsgs(){
    return {
      mail:{
        pattern:'Email address is not correct'
      },
      identity:{
        required:'Passport is required',
        pattern:'The passport contains only numbers'
      },
      name:{
        required:'Name Is required'
      },
      birthDate:{
        required:'Date of birth is required'
      },
      phoneNumber:{
        pattern:'The phone contains only numbers'
      }
    }
  }
  getErrorMsg(control:any, prop:string){
    let errors = (this.errorMsgs as any)[prop]
    if(!control[prop] || !control.isValid){
      const keys = Object.keys(errors);
      for(const key of keys){
        if(control[prop] && !control.isValid){
          return errors['pattern']
        }
        else{
          return errors[key]
        }
      }
    }
    return null;
  }
}

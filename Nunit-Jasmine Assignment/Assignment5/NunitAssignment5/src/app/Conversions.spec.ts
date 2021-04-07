import { TestBed } from '@angular/core/testing';
import {Conversions} from '../app/Conversions';

describe('StringTest',()=>{
    let data:any;
    beforeEach(async () => {
        data=new Conversions();
      });
    
    // Pass input as lowercase and get input converted to uppercase
    it('should return uppercase value on passing lowercase input',()=>{
        let value="dhruvi";
        expect(data.covertToUpperCase(value)).toEqual("DHRUVI");
    });

     // Pass input as uppercase and get input converted to uppercase
     it('should return uppercase value on passing uppercase input',()=>{
        let value="DHRUVI";
        expect(data.covertToUpperCase(value)).toEqual("DHRUVI");
    });

     // Pass input as mixcase and get input converted to uppercase
     it('should return uppercase value on passing mixcase input',()=>{
        let value="DhRuVi";
        expect(data.covertToUpperCase(value)).toEqual("DHRUVI");
    });
    
    // Pass input as uppercase and get input converted to lowercase
    it('should return lowecase value on passing uppercase input',()=>{
        let value="HELLO";
        expect(data.convertToLowerCase(value)).toEqual("hello");
    });
   
     // Pass input as lowercase and get input converted to lowercase
     it('should return lowecase value on passing lowercase input',()=>{
        let value="hello";
        expect(data.convertToLowerCase(value)).toEqual("hello");
    });

     // Pass input as mixcase and get input converted to lowercase
     it('should return lowecase value on passing mixcase input',()=>{
        let value="HeLlO";
        expect(data.convertToLowerCase(value)).toEqual("hello");
    });
   
    
})
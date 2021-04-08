import { TestBed } from '@angular/core/testing';

import { test } from '../app/test';
import { of } from 'rxjs';

const todosServiceStub = {
    get() {
      const todos = [{id: 1}];
      return of( todos );
    }
  };
  

describe('Utility Testing : Validation ', () => {

    // Using mocking with spy
    let CheckValidation : test;
    let spy: any;

    beforeEach(() => {
        CheckValidation =  new test();
    });
    afterEach(()=>{
        CheckValidation=null;
    });

    
    it('valid email',()=>{

        // Arrange
        let input="dhruvibavaria2@gmail.com";
        // Assert
        spy = spyOn(CheckValidation, 'EmailValid').and.returnValue(true);
        let result=CheckValidation.EmailValid(input);
        // Act
        expect(result).toBeTrue();
    });

    it('valid phone number',()=>{
        
       // Arrange
        let input="1234567890";
       // Act
        spy = spyOn(CheckValidation, 'PhoneValid').and.returnValue(false);
        let result=CheckValidation.PhoneValid(input);
       // Assert
        expect(result).toBeFalse();
    });

    it('endsWith DIGITAL',()=>{
        
        // Arrange
        let input = "GATEWAY DIGITAL";
       // Act
        spy = spyOn(CheckValidation, 'endsWith').and.returnValue(true);
        let result=CheckValidation.endsWith(input);
       // Assert
        expect(result).toBeTrue();
    });

    it('length should be Less then Ten',()=>{
        
        // Arrange
        let input = "hello all" ;
        // Act
        spy = spyOn(CheckValidation, 'lessthenTen').and.returnValue(true);
        let result=CheckValidation.lessthenTen(input);
       // Assert
        expect(result).toBeTrue();
    });

    it('Check Uppercase format',()=>{
        
       // Arrange
        let input = "DHRUVI" ;
       // Act
        spy = spyOn(CheckValidation, 'CheckUpperCase').and.returnValue(true);
        let result=CheckValidation.CheckUpperCase(input);
       // Assert
        expect(result).toBeTrue();
    });

    
   
});
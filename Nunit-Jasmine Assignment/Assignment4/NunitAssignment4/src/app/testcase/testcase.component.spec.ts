


import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestcaseComponent } from './testcase.component';



describe('Utility Testing : Character ', () => {

    // Using original instance of util class
    let checkTestCase :  TestcaseComponent ;

    // Using mock instance of util class
    let mockcheckTestCase :  TestcaseComponent ;

    beforeEach(() => {
        checkTestCase = new  TestcaseComponent ();
       
    });
    afterEach(()=>{
        checkTestCase=null;
      
    });


    it('square',()=>{

      // Arrange
      let input = 20 ;
      // Act
      let result = checkTestCase.sqr(input);
      // Assert
      expect(result).toEqual(400);
  });
 

    it('sub 10 ',()=>{

      // Arrange
      let input = 10 ;
      // Act
      let result = checkTestCase.sub(input);
      // Assert
      expect(result).toEqual(0);
  }); 

    it('Add 10 ',()=>{

        // Arrange
        let input = 40 ;
        // Act
        let result = checkTestCase.addition(input);
        // Assert
        expect(result).toEqual(50);
    });
      
    it('mul by 5 ',()=>{

        // Arrange
        let input = 6 ;
        // Act
        let result =  checkTestCase.mul(input);
        // Assert
        expect(result).toEqual(30);
    });
 
    it('divide by 10 ',()=>{

        // Arrange
        let input = 50 ;
        // Act
        let result =  checkTestCase.div(input);
        // Assert
        expect(result).toEqual(5);
    });
    
   
});
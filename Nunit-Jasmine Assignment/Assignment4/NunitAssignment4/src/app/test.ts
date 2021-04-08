import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class test {
  
    EmailValid(email): boolean {
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regularExpression.test(String(email).toLowerCase());
    }

    PhoneValid(phone): boolean {
        const regularExpression = /[0-9\+\-\ ]/;
        return regularExpression.test(String(phone).toLowerCase());
    }

    endsWith(val) {
        if (val.endsWith('DIGITAL')) { 
            return true; 
        }
        return false;
    }

    lessthenTen(data) {
        if (data.length < 10) {
            return true;
        }
        return false;
    }

    CheckUpperCase(data)
    {
       
         var ln = data.length;

            for (var i = 0; i < ln; i++)
            {
                if (data[i] >= 'a' && data[i] <= 'z')
                {
                    return false;
                }
            }
            return true;
    }
    
  }

 


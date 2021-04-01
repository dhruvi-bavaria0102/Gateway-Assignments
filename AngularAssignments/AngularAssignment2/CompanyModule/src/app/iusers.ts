export interface Iusers {
  
 
        id: number;  
        email:string;
        name: string;  
        totalEmployee: number;  
        address:string;
        totalBranch:number;
        isCompanyActive:boolean; 
}
export interface branch
{
        
    
       
        branchId:number;
        branchName:string;
        Address:string;
        users:Iusers[];
    }
        
        


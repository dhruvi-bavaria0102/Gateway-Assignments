import { TestBed } from '@angular/core/testing';
import { Employee } from './Employee';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { EmployeeService } from './employee.service';
import {HttpClientModule} from '@angular/common/http';
describe('EmployeeService', () => {
  let service: EmployeeService;
  const Data: Employee   = {
    "id": 1,
    "email": "dhruvibavaria@gmail.com",
    "name": "Dhruvi Bavaria", 
    "address": "Ankleshwar",
   };
  let httpMock:any;
  let spy:any;
  beforeEach(() => {
    TestBed.configureTestingModule({imports:[HttpClientTestingModule,HttpClientModule],
      providers:[EmployeeService]});
    service = TestBed.inject(EmployeeService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be retrive all data ', () => {
    expect(service).toBeTruthy();
  });

  /*Should check data is coming from url. */
  it('should GET(Retrive) the data', () => {
    const Data: Employee[]   = [{
      "id": 1,
      "email": "infotech@info.co.in",
      "name": "IntoTech",
      "address": "S.G Highway",
    }];
    service.getJSON().subscribe(posts => {
        expect(posts.length).toBe(1);
        expect(posts).toEqual(Data);
      }); 
    const req = httpMock.expectOne(service.baseURL  + 'employee');
    expect(req.request.method).toBe('GET');
    req.flush(Data);
    httpMock.verify();
   });

  /*Should check data is adding into file */
  it('should POST(Add) the data', () => { 
      service.addEmployee(Data).subscribe((data: any) => {});
      const req = httpMock.expectOne(service.baseURL  + 'employee');
      expect(req.request.method).toBe('POST');
      req.flush(Data);
      httpMock.verify();
  });
  /*Update data */
  it('should PUT(Update) the data', () => {  
    service.updateData(3, Data).subscribe((data: any) => {});
    const req = httpMock.expectOne(service.baseURL  + 'employee/' + 3);
    expect(req.request.method).toBe('PUT');
    req.flush(Data);
    httpMock.verify();
  });
  /*Delete entry */
  it('should DELETE(Delete) the data', () => {
    service.deleteData(3);
    const req = httpMock.expectOne(service.baseURL  + 'employee/' + 3);
    expect(req.request.method).toBe('DELETE');
    req.flush(3);
    httpMock.verify();
  });
});

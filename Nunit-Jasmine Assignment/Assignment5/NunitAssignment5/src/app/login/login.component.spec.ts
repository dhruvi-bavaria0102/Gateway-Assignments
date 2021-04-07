import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthenticationService } from '../authentication.service';

import { LoginComponent } from './login.component';

// Fake with fake classes
class MockAuthService { 
  authenticated = false;

 isAuthenticated() {
   return this.authenticated;
 }
}
describe('LoginComponent', () => {
  let component: LoginComponent;
  let component1: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let service: AuthenticationService;
  let service1: MockAuthService;
  let spy: any;
  beforeEach(async () => { (1)
    service = new AuthenticationService();
    service1=new MockAuthService();
    component = new LoginComponent(service);
    component1=new LoginComponent(service1);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('needsLogin returns true when the user has not been authenticated', () => {
    service1.authenticated = false; (3)
    expect(component1.needsLogin()).toBeTruthy();
  });

  it('needsLogin returns false when the user has been authenticated', () => {
    service1.authenticated = true; (3)
    expect(component1.needsLogin()).toBeFalsy();
  });

  it('needsLogin returns true when the user has not been authenticated', () => {
    spy = spyOn(service, 'isAuthenticated').and.returnValue(false); (3)
    expect(component.needsLogin()).toBeTruthy();
    expect(service.isAuthenticated).toHaveBeenCalled(); (4)

  });

  it('needsLogin returns false when the user has been authenticated', () => {
    spy = spyOn(service, 'isAuthenticated').and.returnValue(true);
    expect(component.needsLogin()).toBeFalsy();
    expect(service.isAuthenticated).toHaveBeenCalled();
  });
});

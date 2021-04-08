import { async, ComponentFixture, fakeAsync, flush, TestBed } from '@angular/core/testing';

import { SignupComponent } from './signup.component';

describe('SignupComponent', () => {
  let component: SignupComponent;
  let fixture: ComponentFixture<SignupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should demonstrate isolated testing behavior for async with promises', async(() => {
    component.addNewUser().then(() => {
        expect(component.userSignupCount).toBe(3);
    });

    component.addNewUser();

    component.addNewUser();
}));

it('should demonstrate isolated testing behavior for fakeAsync with promises', fakeAsync(() => {

    component.addNewUser();
    component.addNewUser();
    component.addNewUser();
    component.addNewUser();
    component.addNewUser();
    expect(component.userSignupCount).toBe(0);
    flush();

    expect(component.userSignupCount).toBe(5);
    expect(component.isMaxUsers).toBe(false);

    component.addNewUser();
    flush();
    expect(component.userSignupCount).toBe(5);
    expect(component.isMaxUsers).toBe(true);
}));

it('should demonstrate shallow testing behavior with a failing test for fakeAsync with promises', fakeAsync(() => {
    component.addNewUser();

    flush();

    expect(component.userSignupCount).toBe(1);

    const htmlPreBinding = fixture.nativeElement.querySelector('h1');

    expect(htmlPreBinding.textContent).toBe('0');
}));

it('should demonstrate shallow testing behavior for fakeAsync with promises', fakeAsync(() => {
    component.addNewUser();
    flush();

    expect(component.userSignupCount).toBe(1);

    const htmlPreBinding = fixture.nativeElement.querySelector('h1');

    expect(htmlPreBinding.textContent).toBe('0', 'data bindings not updated to to manual change detection');

    fixture.detectChanges();

    const htmlPostBonding = fixture.nativeElement.querySelector('h1');

    expect(htmlPostBonding.textContent).toBe('1', 'data bindings now up to date after manual change detection');
}));


  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

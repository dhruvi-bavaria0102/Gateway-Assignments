import { async, ComponentFixture, fakeAsync, flush, TestBed } from '@angular/core/testing';

import { RegisterComponent } from './Register.component';

describe('SignupComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should demonstrate isolated testing behavior for async with promises', async(() => {
    component.NewUser().then(() => {
        expect(component.userRegisterCount).toBe(3);
    });

    component.NewUser();

    component.NewUser();
}));

it('should demonstrate isolated testing behavior for fakeAsync with promises', fakeAsync(() => {

    component.NewUser();
    component.NewUser();
    component.NewUser();

    expect(component.userRegisterCount).toBe(0);
    flush();

    expect(component.userRegisterCount).toBe(3);
    expect(component.isMaxUsers).toBe(false);

    component.NewUser();
    flush();
    expect(component.userRegisterCount).toBe(3);
    expect(component.isMaxUsers).toBe(true);
}));

it('should demonstrate shallow testing behavior with a failing test for fakeAsync with promises', fakeAsync(() => {
    component.NewUser();

    flush();

    expect(component.userRegisterCount).toBe(1);

    const htmlPreBinding = fixture.nativeElement.querySelector('h1');

    expect(htmlPreBinding.textContent).toBe('0');
}));

it('should demonstrate shallow testing behavior for fakeAsync with promises', fakeAsync(() => {
    component.NewUser();
    flush();

    expect(component.userRegisterCount).toBe(1);

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

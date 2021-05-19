import { async, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let fixture:any, nativeElement:any;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    nativeElement = fixture.nativeElement;
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'NunitAssignment6'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('NunitAssignment6');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.content span').textContent).toContain('NunitAssignment6 app is running!');
  });

  describe('fakeasync',()=>{
    
    it('whenStable should be used with browser click', fakeAsync(() => {
      fixture.detectChanges(); 
  
      const button = nativeElement.querySelector('div');
      button.click(); 
      expect(fixture.isStable()).toBe(false);
  
      tick(3000); 
      fixture.whenStable().then(() => {
        expect(fixture.isStable()).toBe(true);
        fixture.detectChanges(); 
        expect(nativeElement.querySelector('p').textContent).toBe('111');
      });
    }));

    it('whenStable not required for fakeAsync for isolated test', fakeAsync(() => {
      fixture.componentInstance.click();
      expect(fixture.isStable()).toBe(true);
      tick(2000);
      expect(fixture.componentInstance.text).toBe('11');
    }));
    })
  
    describe('async', () => {
      it('whenStable to be used for shallow component test', async(() => {
        fixture.detectChanges(); 
  
        expect(fixture.isStable()).toBe(false);
  
        fixture.whenStable().then(() => {
          expect(fixture.isStable()).toBe(true);
          fixture.detectChanges(); 
          expect(nativeElement.querySelector('p').textContent).toBe('11');
        });
      }));

      it('whenStable to be used with browser click', async(() => {
        fixture.detectChanges(); 
  
        const button = nativeElement.querySelector('div');
        button.click(); 
        expect(fixture.isStable()).toBe(false);
  
        fixture.whenStable().then(() => {
          fixture.detectChanges(); 
          expect(nativeElement.querySelector('p').textContent).toBe('111');
        });
      }));
    });
  
    describe('done', () => {
      it('whenStable to be used in shallow test with fixture OnInit', done => {
        fixture.detectChanges();
  
        expect(fixture.isStable()).toBe(false);
        fixture.whenStable().then(() => {
          expect(fixture.isStable()).toBe(true);
          fixture.detectChanges(); 
          expect(fixture.nativeElement.querySelector('p').textContent).toBe('11');
          done();
        });
      });
      it('whenSatble to be used in shallow test with browser click', done => {
        expect(fixture.nativeElement.querySelector('p').textContent).toBe('');
  
        const button = fixture.nativeElement.querySelector('div');
        button.click();
  
        expect(fixture.isStable()).toBe(false);
        fixture.whenStable().then(() => {
          expect(fixture.isStable()).toBe(true);
          fixture.detectChanges();
          expect(fixture.componentInstance.text).toBe('11');
          expect(fixture.nativeElement.querySelector('p').textContent).toBe('11');
          done();
        });
      });
    });  
});

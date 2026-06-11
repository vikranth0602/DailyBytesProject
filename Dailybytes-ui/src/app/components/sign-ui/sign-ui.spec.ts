import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUi } from './sign-ui';

describe('SignUi', () => {
  let component: SignUi;
  let fixture: ComponentFixture<SignUi>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SignUi],
    }).compileComponents();

    fixture = TestBed.createComponent(SignUi);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

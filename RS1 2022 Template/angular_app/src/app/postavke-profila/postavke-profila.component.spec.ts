import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostavkeProfilaComponent } from './postavke-profila.component';

describe('PostavkeProfilaComponent', () => {
  let component: PostavkeProfilaComponent;
  let fixture: ComponentFixture<PostavkeProfilaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostavkeProfilaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostavkeProfilaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

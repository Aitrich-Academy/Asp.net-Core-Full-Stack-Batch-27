import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent {
  @Input() educationLogo: any;
  @Input() educationHead: any;
  @Input() educationDescription1: any;
  @Input() educationDescription2: any;
  @Input() educationDescription3: any;
}

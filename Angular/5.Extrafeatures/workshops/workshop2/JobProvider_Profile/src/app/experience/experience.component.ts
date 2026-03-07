import { Component ,Input} from '@angular/core';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent {
  @Input() experienceLogo: any;
  @Input() experienceHead: any;
  @Input() experienceDescription1: any;
  @Input() experienceDescription2: any;
}

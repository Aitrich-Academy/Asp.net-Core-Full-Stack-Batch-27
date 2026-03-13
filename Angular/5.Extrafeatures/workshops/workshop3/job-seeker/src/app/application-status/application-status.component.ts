import { Component, Input ,ElementRef} from '@angular/core';
import { Job } from '../job';


@Component({
  selector: 'app-application-status',
  templateUrl: './application-status.component.html',
  styleUrls: ['./application-status.component.css']
})

export class ApplicationStatusComponent {

  @Input() status:boolean =false;
  @Input() value:any[] | undefined;
  @Input() applicationStatus:string | undefined;
  // applicationStatus:any | undefined;


  timelineData = [
    { applicationStatus:'Applied',image: '../../assets/images/status.png',applied:false, applicationSent: false, accepted: false },
    { applicationStatus:'Application Sent', image: '../../assets/images/status.png', applied:false,applicationSent: false, accepted: true },
    {  applicationStatus:'Accepted',image: '../../assets/images/status.png',applied:false, applicationSent: false, accepted: false }
  ];

  constructor(private elementRef: ElementRef) {}
  ngOnInit(){
    this.printValues();
  }

  navigateTo(index: number): void {
    const timelinePoints = this.elementRef.nativeElement.querySelectorAll('.timeline-point');
    timelinePoints[index].scrollIntoView({ behavior: 'smooth' });
  }
  
  content:any[]=[
            {id:1,title:"Applied"},
            {id:2,title:"Application sent"},
            {id:3,title:"Accepted"}
          ]

          printValues(){
            console.log(this.applicationStatus);
          //  this.applicationStatus=this.applicationStatus=console.log(this.job[0].status);
          }
          
}

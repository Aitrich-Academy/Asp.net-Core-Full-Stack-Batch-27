import { Component } from '@angular/core';
import { Job } from '../job';

@Component({
  selector: 'app-my-applications',
  templateUrl: './my-applications.component.html',
  styleUrls: ['./my-applications.component.css']
})
export class MyApplicationsComponent {

  showStatus:boolean=true;
  counter:boolean=false;
  applyStatus:string | undefined;

 
  events:any[]=[{content:'Applied'},
                {content:'Appplication Sent'},
                {content:'Accepted'}]

  jobs: Job[] = [
    {
      designation: 'Software Developer',
      companyLogo: 'assets/images/rec.png',
      companyName: 'ABC Company',
      isFeatured: true,
      text1: 'Full-time',
      text2: 'Mid-level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      status:'R'
      
    },
    {
      designation: 'UX Designer',
      companyLogo: 'assets/images/cde.png',
      companyName: 'XYZ Company',
      isFeatured: true,
      text1: 'Full-time',
      text2: 'Mid-level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      status:'R'
      
    },
    {
      designation: 'Dot Net Developer',
      companyLogo: 'assets/images/abc.png',
      companyName: 'PRNV Company',
      isFeatured: true,
      text1: 'Full-time',
      text2: 'Mid-level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      status:''
     
    },{
      designation: 'UX Designer',
      companyLogo: 'assets/images/cde.png',
      companyName: 'XYZ Company',
      isFeatured: true,
      text1: 'Full-time',
      text2: 'Mid-level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
     status:''
    },
    {
      designation: 'Dot Net Developer',
      companyLogo: 'assets/images/abc.png',
      companyName: 'PRNV Company',
      isFeatured: true,
      text1: 'Full-time',
      text2: 'Mid-level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      status:''
    }
    
    // Add more job objects as needed
];
clicked(status:any){
  this.counter=true;
  this.applyStatus=status;
}

}




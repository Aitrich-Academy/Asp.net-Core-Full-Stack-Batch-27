import { Component } from '@angular/core';

@Component({
  selector: 'app-all-jobs',
  templateUrl: './all-jobs.component.html',
  styleUrls: ['./all-jobs.component.css']
})
export class AllJobsComponent {
  jobs: any[] = [
    {
      jobId : 1,
      designation: 'UI/UX Designer',
      companyLogo: 'assets/images/Rectangle 14 (2).png',
      companyImg : 'assets/images/Shopee.jpg',
      companyName: 'Shopee',
      isFeatured: true,
      save: 'assets/images/archive-minus.png',
      jobtext: 'We are looking for a UI/UX Designer to turn our software into easy-to-use products for our clients.',
      text1: 'Full-time',
      text2: 'Mid Level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      companyContent : 'company description goes here',
      jobDesc : 'Job Description content goes here',
      responsibilities :'Job responsibilities goes here'
    },
    {
      jobId: 2,
      designation: 'Product Designer',
      companyLogo: 'assets/images/Group 5695.png',
      companyImg : 'assets/images/Rectangle 11.png',
      companyName: 'amazone',
      isFeatured: true,
      save: 'assets/images/Group 5696.png',
      jobtext: 'We are looking for a UX Designer to design software and platforms easy-to-use products for our clients. ',
      text1: 'Full-time',
      text2: 'All Level',
      text3: '$2000-$3000',
      text4: 'Indonesia',
      text5: 'Onsite',
      companyContent : ' Amazon is an American multinational technology company that specializes in e-commerce, cloud computing, online advertising, digital streaming, and artificia intelligence. It has been referred to as "one of the most influential economic and cultural forces in the world", and is one of the  worlds most valuable brands. Amazon is one of the Big Five American information technology companies, alongside  Alphabet (Google), Apple, Meta (Facebook),and Microsoft.',
      jobDesc : 'Job Description content goes here',
      responsibilities :'Job responsibilities goes here'
    },
    {
      jobId: 3,
      designation: 'UI Designer',
      companyLogo: 'assets/images/Rectangle 14.png',
      companyImg : 'assets/images/lazada.png',
      companyName: 'Lazada',
      isFeatured: true,
      save: 'assets/images/archive-minus.png',
      jobtext: 'Product designer responsibilities include defining product specifications, creating digital or print drawings and designing fully-functional products.',
      text1: 'Full-time',
      text2: 'All Level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      companyContent : 'company description goes here',
      jobDesc : 'Job Description content goes here',
      responsibilities :'Job responsibilities goes here'
    },
    {
      jobId: 4,
      designation: 'UX Designer',
      companyLogo: 'assets/images/Rectangle 14 (1).png',
      companyImg : 'assets/images/ebay.jpg',
      companyName: 'ebay',
      isFeatured: true,
      save: 'assets/images/Group 5696.png',
      jobtext: 'Product designer responsibilities include defining product specifications, creating digital or print drawings and designing fully-functional products.',
      text1: 'Full-time',
      text2: 'All Level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      companyContent : 'company description goes here',
      jobDesc : 'Job Description content goes here',
      responsibilities :'Job responsibilities goes here'
    },
    
    // Add more job objects as needed
  ];

  selectedJob: any = null;

  showJobDetails(job: any) {
    this.selectedJob = job;
  }
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {


  counter(data:number):number[]
  {
    return Array(data);
  }

   count1:number=120;
   color1:string="#13d6af";
   image1:string="../../assets/images/Group 239604.png";
   count2:number=130;
   color2:string="#47b3cd" ;
   image2:string="../../assets/images/ic-search.png";
   count3:number=210;
   color3:string="#4447d7";
   image3:string="../../assets/images/image 2.png";
}

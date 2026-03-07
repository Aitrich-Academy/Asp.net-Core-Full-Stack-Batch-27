import { Component } from '@angular/core';
import { LanguageComponent } from '../language/language.component';
import { EducationComponent } from '../education/education.component';
import { ExperienceComponent } from '../experience/experience.component';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent {
  childData1 = {
    logo:  "../../assets/images/language.png",
    heading: "Languages",
    description: "Operating Systems: Windowws 9x/NT/2000, DOS/Unix/Linux IDE Tools. JBuilder Databases: PL/SQL Languages: Java, C, C++, C#, Asp.Net, PHP Web Technologies: HTML, JSP, Servlets, Struts Framework: Any, Photoshop: Any Application: Any Servers: BEA Weblogic 7.0, Web Servers: Tomcat 5.0, Apache: Any"
  };
  childData2= {
    logo:  "../../assets/images/portfolio 1.png",
    heading: "Education",
    description1: " Bachelor of Arts - Design Field &Fort University",
    description2:"top 10 percentile of the class Master of Arts - GraphicDesign",
    description3:"Nov 13-Dec 17    Mansfield,Ohio    Texas University"

  };
  childData3= {
    logo:  "../../assets/images/portfolio 2.png",
    heading: "Experience",
    description1: "Advertising Speciality Institute,SanFrancisco,TX-Graphic-Designer Dec '18 - June '20",
    description2:"Advertising Age - Graphic Design intern Jan '21 - Nov '22"
   
  };
}

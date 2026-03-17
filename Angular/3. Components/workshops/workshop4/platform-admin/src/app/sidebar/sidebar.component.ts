import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  hoverIn(item:any) {
    item.classList.add('hovered');
  }
  
 hoverOut(item:any) {
    item.classList.remove('hovered');
  }
 
}

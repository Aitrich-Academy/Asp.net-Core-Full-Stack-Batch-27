import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jobseeker-header',
  templateUrl: './jobseeker-header.component.html',
  styleUrls: ['./jobseeker-header.component.css']
})
export class JobseekerHeaderComponent implements OnInit {
  

  isResponsive: boolean = false;
  user: any;

  ngOnInit() {
    this.user = JSON.parse(sessionStorage.getItem('user') as string);
  }

  toggleResponsive() {
    this.isResponsive = !this.isResponsive;
  }

  isDropdownOpen: boolean = false;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  handleMenuClick(event: Event) {
    event.stopPropagation(); // Prevent the click event from propagating to the parent elements
  }

  logout() {
    sessionStorage.removeItem("user")
  }
}

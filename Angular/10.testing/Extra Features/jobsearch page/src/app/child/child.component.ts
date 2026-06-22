import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {
  @Input() selectedJob: any;

  activeTab: string = 'company';

  changeTab(tab: string) {
    this.activeTab = tab;
  }

  constructor() { }

}

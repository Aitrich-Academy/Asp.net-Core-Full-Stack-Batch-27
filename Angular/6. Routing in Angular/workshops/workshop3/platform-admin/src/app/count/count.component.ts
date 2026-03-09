import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-count',
  templateUrl: './count.component.html',
  styleUrls: ['./count.component.css']
})
export class CountComponent {

  @Input() count: number | undefined;
  @Input() color: string | undefined;
  @Input() image: string | undefined;

}

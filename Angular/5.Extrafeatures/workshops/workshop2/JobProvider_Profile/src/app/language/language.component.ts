import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent {
  @Input() languageLogo: any;
  @Input() languageHead: any;
  @Input() languageDescription: any;
}

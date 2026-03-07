import { Component } from '@angular/core';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent {
  chats: any[] = [
    {
      displayPicture:'../../assets/images/Image.png',
      name: 'Amazon HR Manager',
      time:'11:00 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/maersk.png',
      name: 'Maersk HR Manager',
      time:'10:53 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/aitrich.png',
      name: 'Aitrich HR Manager',
      time:'10:50 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/shoppee.png',
      name: 'Shoppee HR Manager',
      time:'10:47 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/flip.png',
      name: 'Flipkart HR Manager',
      time:'10:43 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/elon.png',
      name: 'Elon Musk',
      time:'10:40 AM',
      lastMessage:'Congratulations',
      display: true
    },
    {
      displayPicture:'../../assets/images/google.png',
      name: 'Google HR Manager',
      time:'10:37 AM',
      lastMessage:'Congratulations',
      display: true
    }
  ];

  selectedOption: any;

  selectOption(option: any) {
    this.selectedOption = option;
  }
}

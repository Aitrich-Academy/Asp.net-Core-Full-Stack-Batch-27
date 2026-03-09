import { Component } from '@angular/core';
import { RegistrationService } from '../registration.service';

@Component({
  selector: 'app-remove-registration-details',
  templateUrl: './remove-registration-details.component.html',
  styleUrls: ['./remove-registration-details.component.css']
})
export class RemoveRegistrationDetailsComponent {

  registeredMembers: any[];

  constructor(private registrationService: RegistrationService) {
    this.registeredMembers = registrationService.getRegisteredMembers();
  }

  removeMember(index: number) {
    this.registrationService.removeMember(index);
  }
}

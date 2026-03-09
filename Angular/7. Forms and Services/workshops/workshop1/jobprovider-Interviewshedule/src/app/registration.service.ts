import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  registeredMembers: any[] = [];

  registerMember(member: any) {
    this.registeredMembers.push(member);
  }

  removeMember(index: number) {
    this.registeredMembers.splice(index, 1);
  }

  getRegisteredMembers() {
    return this.registeredMembers;
  }
}

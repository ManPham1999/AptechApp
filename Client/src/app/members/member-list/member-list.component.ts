import { MemberService } from './../../_services/member.service';
import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_model/member';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  members : Member[];
  constructor(private memberservices : MemberService) { }

  ngOnInit(): void {
    this.loadMembers();
  }
  loadMembers() {
    this.memberservices.getMembers().subscribe((x:Member[]) => {
      this.members = x;
    });
  }
}

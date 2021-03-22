import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_model/member';
const httOptions = {
  headers: new HttpHeaders({
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("user"))?.token}`
  })
}
@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl: string = environment.apiUrl;
  username: string;
  constructor(private http: HttpClient) { }

  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(`${this.baseUrl}/user`,httOptions);
  }
  getMember(): Observable<Member> {
    return this.http.get<Member>(`${this.baseUrl}/user/${this.username}`, httOptions);
  }
}

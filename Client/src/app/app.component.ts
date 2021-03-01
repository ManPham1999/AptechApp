import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Welcome to dating app';
  users: object;
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.getUsers();
  }
  getUsers =()=>{
    this.http.get('https://localhost:5001/api/user').subscribe(data =>{
      this.users = data;
    },error =>{
      console.log(error);
    })
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.apiUrl;
  ngOnInit(): void {
  }
  get500() {
    this.http.get(`${this.baseUrl}/buggy/server-error`).subscribe((res) => {
      console.log(res);
    }, err => console.log(err)
    )
  }
  get400() {
    this.http.get(`${this.baseUrl}/buggy/bad-request`).subscribe((res) => {
      console.log(res);
    }, err => console.log(err)
    )
  }
  get401() {
    this.http.get(`${this.baseUrl}/buggy/auth`).subscribe((res) => {
      console.log(res);
    }, err => console.log(err)
    )
  }
  get404() {
    this.http.get(`${this.baseUrl}/buggy/not-found`).subscribe((res) => {
      console.log(res);
    }, err => console.log(err)
    )
  }
  get400ValidationError() {
    this.http.post(`${this.baseUrl}/account/register`, {}).subscribe((res) => {
      console.log(res);
    }, err => console.log(err)
    )
  }
}

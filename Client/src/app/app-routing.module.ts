import { AuthGuard } from './_guard/-auth.guard';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
  { path: 'members/:id', component: MemberDetailComponent , canActivate: [AuthGuard] },
  { path: 'lists', component: ListsComponent , canActivate: [AuthGuard] },
  { path: 'messages', component: MessagesComponent , canActivate: [AuthGuard] },
  { path: '**', component: HomePageComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

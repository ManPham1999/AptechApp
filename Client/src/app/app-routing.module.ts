import { ServerErrorComponent } from './error/server-error/server-error.component';
import { NotFoundComponent } from './error/not-found/not-found.component';
import { TestErrorComponent } from './error/test-error/test-error.component';
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
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [{ path: 'members', component: MemberListComponent, },
    { path: 'members/:username', component: MemberDetailComponent, },
    { path: 'lists', component: ListsComponent, },
    { path: 'messages', component: MessagesComponent, }]
  },
  { path: 'error', component: TestErrorComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'notFound', component: NotFoundComponent },
  { path: '**', component: HomePageComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

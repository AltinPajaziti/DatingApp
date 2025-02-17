import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersComponent } from './members/members.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './home/lists/lists.component';
import { MessagesComponent } from './home/messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberEditComponent } from './interceptors/members/member-edit/member-edit.component';
import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

export const routes: Routes = [


    {path:'' , component: HomeComponent},


    {
        path: '',
        runGuardsAndResolvers:'always',
        canActivate : [authGuard],
        children : [
            {path:'members', component : MembersComponent},
            {path : 'members/:username' , component : MemberDetailComponent},
            { path: 'member/:edit', component: MemberEditComponent, canDeactivate: [preventUnsavedChangesGuard] },

            {path: 'lists' , component : ListsComponent},
            {path : 'messages' , component: MessagesComponent},
            
        ]
    },

    {path : "error" , component : TestErrorsComponent},
    {path : "not-found" , component : NotFoundComponent},
    {path : "server-error" , component : ServerErrorComponent},


    
     {path : "**" , component : HomeComponent , pathMatch:'full'}
];

import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersComponent } from './members/members.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './home/lists/lists.component';
import { MessagesComponent } from './home/messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';

export const routes: Routes = [


    {path:'' , component: HomeComponent},


    {
        path: '',
        runGuardsAndResolvers:'always',
        canActivate : [authGuard],
        children : [
            {path:'members', component : MembersComponent},
            {path : 'members/:id' , component : MemberDetailComponent},
            {path: 'lists' , component : ListsComponent},
            {path : 'messages' , component: MessagesComponent},
            
        ]
    },

    {path : "error" , component : TestErrorsComponent},

    
    // {path : "**" , component : HomeComponent , pathMatch:'full'}
];

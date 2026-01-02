import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'auth/login', pathMatch: 'full' },
    {
        path: 'auth',
        loadChildren: () =>
            import('./auth/auth-module').then(m => m.AuthModule)
    },
    {
        path: 'tasks',
        loadChildren: () =>
            import('./task/task-module').then(m => m.TaskModule)
    },
    { path: '**', redirectTo: 'auth/login' }
];

import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { routes } from './app/app.routes';

bootstrapApplication(App, {
   providers: [
    provideRouter(routes),
    provideHttpClient()
  ]
});

// bootstrapApplication(App, {
//   providers: [
//     provideRouter([
//       { path: '', redirectTo: '/tasks', pathMatch: 'full' },
//       { path: 'tasks', loadComponent: () => import('./app/task/components/task-list/task-list').then(m => m.TaskList) },
//       { path: 'auth/login', loadComponent: () => import('./app/auth/login/login').then(m => m.Login) }
//     ]),
//     provideHttpClient(),
//     provideForms()
//   ]
// }).catch(err => console.error(err));
// function provideForms(): import("@angular/core").Provider | import("@angular/core").EnvironmentProviders {
//   throw new Error('Function not implemented.');
// }


import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideToastr, Toast } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';
import { errorInterceptor } from './interceptors/error.interceptor';
import { jwtInterceptor } from './interceptors/jwt.interceptor';



export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 

    provideHttpClient(withInterceptors([errorInterceptor , jwtInterceptor])),
    provideToastr({
      positionClass: 'toast-bottom-right'
    }),
    provideAnimations()
    
  ]
};

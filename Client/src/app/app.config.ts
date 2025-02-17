import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideToastr, Toast } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';
import { errorInterceptor } from './interceptors/error.interceptor';
import { jwtInterceptor } from './interceptors/jwt.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loadingInterceptor } from './interceptors/loading.interceptor';



export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 

    provideHttpClient(withInterceptors([errorInterceptor , jwtInterceptor,loadingInterceptor])),
    provideToastr({
      positionClass: 'toast-bottom-right'
    }),
    provideAnimations(),
    provideToastr({
      positionClass: 'toast-bottom-right'
    }),

    importProvidersFrom(NgxSpinnerModule)


    
  ]
};

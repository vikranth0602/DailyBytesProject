import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';

import { catchError, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const user = localStorage.getItem('user');

    let clonedReq = req;

    if (user) {
      const parsedUser = JSON.parse(user);

      
if (parsedUser.token)
{
  clonedReq = req.clone({
    setHeaders:
    {
      Authorization:
        `Bearer ${ parsedUser.token }`
    }
  });
}


    }

    return next(clonedReq).pipe(

   
catchError((error: HttpErrorResponse) =>
{
  console.log(
    'HTTP ERROR:',
    error
  );

  if (error.status === 401)
  {
    localStorage.removeItem('user');
  }

  return throwError(() => error);
})


    );
  };

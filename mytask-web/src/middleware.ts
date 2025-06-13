import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';

export async function middleware(request: NextRequest) {

    const { pathname } = request.nextUrl;
    const authToken = request.cookies.get('authToken')?.value;

    const isAuthenticated = !!authToken; 
    //const isPublicPath = publicPaths.includes(pathname);

    console.log(`Middleware IsAuthenticated: ${isAuthenticated}`);
  
    if (!isAuthenticated) {
       
        if (pathname === '/login') {
            console.log('Middleware: Unauthenticated, on /login, allowing access.');
            return NextResponse.next();
        }
  
        const loginUrl = new URL('/login', request.url);
        loginUrl.searchParams.set('redirect', pathname); 

        return NextResponse.redirect(loginUrl);
    }
      
    if (isAuthenticated && pathname === '/') {
         console.log('Middleware: Authenticated, on /, redirecting to /home.');
        return NextResponse.redirect(new URL('/home', request.url));
    }
    console.log(`Middleware: Allowing access for ${pathname}`);
    return NextResponse.next();
}

export const config = {
    matcher: ['/((?!api|_next/static|_next/image|favicon.ico).*)'],
};
import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';

export async function middleware(request: NextRequest) {

    const { pathname } = request.nextUrl;
    const authToken = request.cookies.get('authToken')?.value;

    const isAuthenticated = !!authToken; 
    //const isPublicPath = publicPaths.includes(pathname);
  
    if (!isAuthenticated) {
       
        if (pathname === '/login') {
            return NextResponse.next();
        }
  
        const loginUrl = new URL('/login', request.url);
        loginUrl.searchParams.set('redirect', pathname); 

        return NextResponse.redirect(loginUrl);
    }
      
    if (isAuthenticated && pathname === '/') {
        return NextResponse.redirect(new URL('/home', request.url)); // Or '/home'
    }

    return NextResponse.next();
}

export const config = {
    matcher: ['/((?!api|_next/static|_next/image|favicon.ico).*)'],
};
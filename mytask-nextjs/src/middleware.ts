import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';


//Define paths that do NOT require authentication
//const publicPaths = ['/login']; // Add any other public pages

export async function middleware(request: NextRequest) {

    const authToken = request.cookies.get('authToken')?.value;
    console.log('Auth Token from cookies:', authToken);

    const { pathname } = request.nextUrl;
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
      
    if (authToken && pathname === '/') {
        return NextResponse.redirect(new URL('/home', request.url)); // Or '/home'
    }

    return NextResponse.next();
}

export const config = {
    matcher: ['/((?!api|_next/static|_next/image|favicon.ico).*)'],
};
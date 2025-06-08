import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';

// Define paths that do NOT require authentication
const publicPaths = ['/login', '/signup', '/forgot-password']; // Add any other public pages

export function middleware(request: NextRequest) {
    const { pathname } = request.nextUrl;

    // Simulate authentication status (replace with your actual auth check)
    // This could involve checking a cookie, a token in localStorage (if it's a client-side middleware
    // but typically middleware is server-side so it checks cookies), or a server-side session.
    // For demonstration, let's assume `isAuthenticated` is a boolean from your auth logic.
    // In a real app, you'd parse a cookie like:
    // const sessionCookie = request.cookies.get('sessionToken');
    // const isAuthenticated = !!sessionCookie; // Or validate the token
    const isAuthenticated = false; // <<< REPLACE WITH YOUR ACTUAL AUTH CHECK (e.g., from a cookie)

    // 1. If the user is trying to access a public path, allow them through
    if (publicPaths.includes(pathname)) {
        return NextResponse.next();
    }

    // 2. If the user is NOT authenticated and tries to access '/', redirect to '/login'
    //    Also handles any other protected path if not authenticated
    if (!isAuthenticated) {
        // If the user is already on the login page (or trying to access it), allow it.
        // This prevents an infinite redirect loop.
        if (pathname === '/login') {
            return NextResponse.next();
        }
        // Redirect to login page, preserving the original URL in a query param
        // This allows you to redirect them back after successful login
        const loginUrl = new URL('/login', request.url);
        loginUrl.searchParams.set('redirect', pathname); // Add current path as redirect param
        return NextResponse.redirect(loginUrl);
    }

    // 3. If the user IS authenticated, and they are trying to access '/',
    //    redirect them to your main app page (e.g., /dashboard or /home)
    if (isAuthenticated && pathname === '/') {
        return NextResponse.redirect(new URL('/home', request.url)); // Or '/home'
    }

    // 4. If none of the above conditions are met, allow the request to proceed
    return NextResponse.next();
}

// Optionally, configure which paths the middleware should run on.
// This is important for performance, to avoid running middleware on static assets, etc.
export const config = {
    matcher: [
        /*
         * Match all request paths except for the ones starting with:
         * - _next/static (static files)
         * - _next/image (image optimization files)
         * - favicon.ico (favicon file)
         * - You might also want to exclude /api routes if they don't need auth checks here.
         */
        '/((?!api|_next/static|_next/image|favicon.ico).*)',
    ],
};
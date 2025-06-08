import Link from "next/link";

export default function Home() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <div className="w-full max-w-md p-6 bg-white rounded-lg shadow-md">
        <h1 className="text-2xl font-bold text-center mb-6">Welcome to the Home Page!</h1>
        <p className="text-center mb-4">This is the home page of our application.</p>
        <Link href="/main" className="text-blue-500 hover:underline">
          Go to Main Page
        </Link>
      </div>
    </div>
  );
}
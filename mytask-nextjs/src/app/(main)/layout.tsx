import Link from "next/link";

export default function MainLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <div className="w-full max-w-md p-6 bg-white rounded-lg shadow-md">
        <h1 className="text-2xl font-bold text-center mb-6">Welcome to the Main Layout!</h1>
        {children}
        <p className="mt-4 text-center">
          Go back to{" "}
          <Link href="/" className="text-blue-500 hover:underline">
            Home
          </Link>
        </p>
      </div>
    </div>
  );
}
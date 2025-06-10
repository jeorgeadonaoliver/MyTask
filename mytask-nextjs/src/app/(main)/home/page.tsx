'use server';

import Card from "@/app/shared/components/card";

export default async function Home() {
  // const cookieStore = cookies();
  // const token = (await cookieStore).get('authToken')?.value;

  // const res = await axiosBase.get('api/Home/Home', {
  //   headers: {
  //     Authorization: `Bearer ${token}`,
  //   }
  // });

  return (
    <div className="flex flex-col items-center justify-center min-h-screen">
      <Card title={""} icon={undefined}>
        <div className="w-full max-w-md p-6 text-white rounded-lg">
          <h1 className="text-2xl font-bold text-center mb-6">TEST ONLY</h1>
          <p className="text-center mb-4">This is the home page of our application.</p>
        </div>
      </Card>
      
    </div>
  );
}
'use client';

import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { useState } from 'react';

export function QueryProvider({ children }: { children: React.ReactNode }) {
  const [queryClient] = useState(() => new QueryClient({
    defaultOptions: {
      queries: { staleTime: 5 * 60_000, refetchOnWindowFocus: false },
      mutations: { retry: 1 },
    }
  })
);

  return <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>;
}

import { Bid } from './bid';

export interface Job {
  jobId: number;
  description: string;
  requirements: string;
  posterName: string;
  contactInfo: string;
  createdAt: string;
  expirationDate: string;
  bids: Bid[];
  lowestBid: number | null;
  bidCount: number;
}

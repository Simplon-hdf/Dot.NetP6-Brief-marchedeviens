import { ReverseObservablePipe } from './reverse-observable.pipe';

describe('ReverseObservablePipe', () => {
  it('create an instance', () => {
    const pipe = new ReverseObservablePipe();
    expect(pipe).toBeTruthy();
  });
});

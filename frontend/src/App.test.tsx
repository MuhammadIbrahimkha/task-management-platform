import { render, screen } from '@testing-library/react'
import { describe, expect, it } from 'vitest'
import App from './App'

describe('App', () => {
  it('renders the task workspace welcome message', () => {
    render(<App />)

    expect(
      screen.getByRole('heading', { name: 'Your task workspace starts here.' }),
    ).toBeInTheDocument()
    expect(
      screen.getByText(
        'Organize your work and keep track of what needs to get done.',
      ),
    ).toBeInTheDocument()
  })
})

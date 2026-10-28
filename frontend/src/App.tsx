import './App.css'

function App() {
  return (
    <main className="app-shell">
      <header className="app-header">
        <p className="app-brand">Task Management Platform</p>
      </header>
      <section className="welcome-panel" aria-labelledby="welcome-heading">
        <p className="eyebrow">Workspace</p>
        <h1 id="welcome-heading">Your task workspace starts here.</h1>
        <p className="welcome-description">
          Organize your work and keep track of what needs to get done.
        </p>
      </section>
    </main>
  )
}

export default App

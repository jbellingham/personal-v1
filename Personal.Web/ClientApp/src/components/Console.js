import React from "react"
import { ConsoleLine } from "./ConsoleLine"

export class Console extends React.Component {
  static displayName = Console.name

  render() {
    return (
      <div
        style={{
          backgroundColor: "#383737",
          borderTop: "10px solid #ccc",
          borderBottom: "10px solid #ccc",
          borderRadius: "5px",
        }}
      >
        <ConsoleLine lineTitle="let jesse = new Jesse()" />
        <ConsoleLine />
        <ConsoleLine
          lineTitle="jesse.name"
          lineDescription="Jesse Bellingham"
        />
        <ConsoleLine lineTitle="jesse.location" lineDescription="Melbourne" />
        <ConsoleLine
          lineTitle="jesse.education"
          lineDescription="Bachelor of Information Technology (Software Development)"
        />
        <ConsoleLine
          lineTitle="jesse.skills"
          lineDescription=".Net, React.js, Angular, jQuery, PostgreSQL"
        />
        <ConsoleLine
          lineTitle="jesse.interests"
          lineDescription="Coding, gaming, live music, snowboarding, powerlifting"
        />
        <ConsoleLine
          lineTitle="jesse.email"
          lineDescription="jbellingham91@gmail.com"
          lineLink="mailto:jbellingham91@gmail.com"
        />
      </div>
    )
  }
}

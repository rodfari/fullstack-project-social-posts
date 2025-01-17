# Strider Technical Assessment Briefing

This briefing is to give you information to be as successful as possible in Strider Technical Assessment. The STA is a take-home coding test that you can do on your own computer at the time you find best.

⚠️ The results of your assessment will be visible to multiple companies and are very important for your profile evaluation. The solution you design, implement and deliver works as a sample of your work so a really good opportunity to show off your skills.
Keep in mind that you may need several hours to finish the assessment but your results are valid for multiple opportunities. That said, you can be very efficient if delivering a great job.

Here are some tips to help you be successful:

- Keep your focus on addressing the challenge (remember you have time constraints)
- Don't ignore the importance of non-code artifacts (e.g written content, organization, decisions reasoning comments, diagrams, etc)
- Make sure you followed every single instruction carefully and ask for clarification if you need help (please refer to the FAQ section)
- Make sure you take some time to think about how you're delivering the results (e.g make sure it doesn't only work on your machine, and you're providing proper instructions and resources)

# Instructions

- Suggested time to complete the test is located in the test itself. The number of suggested hours ranges from 4-8hrs depending on the test. This does not include the time to set up your environment.
- Do not post this test anywhere on the public internet (including Github, Gitlab, etc.)
- We recommend using the programming language and frameworks you are most familiar with to solve the problem
- Make sure to include instructions in the README for the reviewer to be able to set up your project in his or her local environment.
- Reviewers will only see what is in your ZIP file, so make sure that any comments that you want to make about the project are left in the README.
- Write your name towards the top of your README; this helps us identify solutions after unzipping more easily
- The code you write should be as production-ready as possible given the time constraints.
- Use git during your development process and commit regularly and intelligently. Use it as you would use it in a production project (don’t just dump everything into one commit). We will read your commit messages and evaluate how you use git.

# **Submission**

- Save your whole project including **`/.git`** as a ZIP file (please avoid other compression formats), with title in the format "[firstName]-[lastName]-[test-version]-[test-domain-type].zip" e.g., "John-Smith-2-0-web-front-end.zip"
- Do not include on your ZIP file managed packages’ installed files (e.g node_modules, vendor, etc)
- Please include, if any, collections files to help testing your solution (e.g Postman, Insomnia)
- Upload your project to Dropbox or Google Drive and make the link public.

<aside>
➡️ Fill out the submission form: https://form.typeform.com/to/leQMMtIl

</aside>

# What help you can get

- You may use the internet, Google, StackOverflow, libraries, etc to solve the project
- You cannot reference other people's solutions for the same or similar test
- You cannot get outside help from anyone
- You can ask questions about requirements, submission, etc to your Strider recruiter. Before doing so, please check out the FAQ section.

# Evaluation criteria

Below are lists of criteria we check in each technical assessment. Please note that not all criteria apply to every assessment.

- **All Assessments**
    - **Fulfilling requirements**
        - Happy paths
        - Corner cases (validations, constraints, etc)
    - **Architecture choices**
        - API endpoints structuring (methods, paths, parameters)
        - Design patterns (service layers, repositories, mediators, builders, etc)
        - Module/folder organization
        - Technologies (frameworks, libraries, database)
        - Scalability bottlenecks
    - **Cleanliness of the code**
        - General pattern consistency (naming, organization)
        - Presence of clean code practices
        - Code smells (conditional statement nesting, hard-coded values, duplication, method complexity, inconsistent returns, etc)
        - Variables and methods naming (readability)
    - **Use of best practices**
        - Project organization
        - Dependencies management
        - Framework’s recommendations and built-in features usage
        - Configuration management
        - Version control (git commits tree, messages)
    - **Quality of written content (code comments, README)**
        - Required sections in README according to project description
        - Clear instructions to run the project
        - Endpoint documentation
        - Clarity of written English
        - Depth of thought
- Back-end & Data Engineering only
    - **Efficiency of database queries**
        - ORM usage
        - Pagination strategy
        - SQL Join clauses
        - User input sanitization
- Back-end only
    - **Tests**
        - Coverage
        - Chosen types
        - Suite organization
        - Chosen scenarios and assertions
- Front-end only
    - **UX**
        - UX should be reasonably good
        - Colors, style, typography, etc are not important as long as the application is usable
- Web Scraping
    - Parsing strategy
    - Content retrieving strategy (queries, validations, etc)
    - Database modeling
    - Logging strategy
    - Automated tests
- Data Science
    - Quality of written content and visualizations
    - Model design and applicability

# Variations

To accommodate different types of developers, like front-end, back-end, and full-stack, we allow you to choose the variation of the test you want to take. The factors to consider when choosing which variation to take are:

- What you're best at. You'll want to choose the variation that will best show off your skills.
- What job you want next — do you want to be a mobile dev, front-end, full-stack, etc? Companies typically consider applicants for roles based on the test that they take. For example, if they are hiring for a front-end role, they will want to see front-end code in the form of a front-end or full-stack assessment.
    - If you want to be considered for more positions through Strider, you can take this test more than once with different variations. Just let your Strider recruiter know, and we can schedule both.

The available variations are:

- 💻  Web Front-end
- 💻  Web Back-end
- 📱 Mobile
- 💽  Data Engineering - Build an ETL pipeline, answer some questions with SQL, and explain how you would architect the system in a real production environment
- 🕸️  Web Scraping
- 🤖 Data Science - Given a (hypothetical) company scenario and a sample dataset you're expected to (1) design an A/B test proposal to validate some hypotheses, and (2) design and implement a model to perform some analysis based on the provided dataset.

# ❗Environment setup❗

We highly recommend that you set up an environment in your language and framework of choice (according to the variation you choose above) before your scheduled time for the assessment. That will ensure you can spend 100% of your assessment time on writing code for the project rather than wrangling your environment.

# Scheduling & next steps

When you are ready to take the assessment, let our team know* your planned start date and which variation you wish to take. **You’ll have one week to turn it in.**

** You can send us a message through the live chat on the platform ("?" icon on the upper right corner).*

# FAQ

- **Front-end assessments**
    
    **Is there any layout reference I can use?**
    
    No. The candidate is free to design and build the app's interface. A reference app is mentioned in the assessment's instructions but won't have any strict UX/UI validation in that sense. As per instructions, the UX/UI must be reasonably good.
    
    **Am I expected to write automated tests (unit, e2e, visual, etc)?**
    
    While not required, we strongly recommend covering your main features with some automated tests to make sure they work not just while developing. Anyway, keep your focus on the main requirements of the assessment (features).
    
    **Does my layout need to be responsive (CSS)?**
    
    Layout responsiveness isn't one of the main requirements of the assessment, that said, you're free to decide to spend or not some time on this matter since it's a good practice but you have limited time.
    
    **Do the application state expected to persist across page reloads?**
    Yes. That's expected to be a proper demo by the reviewer.
    
    **Is there any API for the front-end challenge?**
    No. Your app is supposed to be built having API communication in mind but real communication won't be required. That said, your app should be functional using a local storage strategy.
    
- **Back-end assessment**
    
    **Should the user be part of my database modeling?**
    
    Yes. You're not expected to provide a way to create/update/delete a user but the model should be part of your database design and handle data as per instructions.
    
    **Why are there screens' details on the back-end assessment?**
    
    The screens descriptions are useful to give you context on how the app is supposed to work so you can design a proper API.
    
    **Is there any technical limitation that needs to be respected when doing the assessment?**
    
    No. Any technical decision or API design is part of the assessment, just ensure to be tied to the given instructions. Also, we encourage candidates to add all the decisions made to the README file to help the evaluator understand and test the solution.
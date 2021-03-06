﻿using NSpec;
using NLog;

class describe_DefaultLogMessageFormatter : nspec {
    void when_created() {
        it["formats string"] = () => {
            var f = new DefaultLogMessageFormatter();
            var logger = new Logger("MyLogger");
            var message = f.FormatMessage(logger, LogLevel.Debug, "hi");
            message.should_be("[DEBUG] MyLogger: hi");
        };

        it["pads logLevel"] = () => {
            var f = new DefaultLogMessageFormatter();
            var logger = new Logger("MyLogger");
            var message1 = f.FormatMessage(logger, LogLevel.Debug, "hi");
            var message2 = f.FormatMessage(logger, LogLevel.Warn, "hi");
            message1.should_be("[DEBUG] MyLogger: hi");
            message2.should_be("[WARN]  MyLogger: hi");
        };
    }
}

